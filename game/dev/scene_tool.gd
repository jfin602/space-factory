extends SceneTree

# Standalone SceneTree tool for Godot's --script entry point.
func _initialize() -> void:
	call_deferred("_run")

func _run() -> void:
	var args := OS.get_cmdline_user_args()
	if args.is_empty():
		_fail("usage: inspect <res://scene.tscn> | automation-smoke")
		return
	match args[0]:
		"inspect":
			if args.size() != 2:
				_fail("inspect requires one scene path")
				return
			_inspect(args[1])
		"automation-smoke":
			_round_trip()
		_:
			_fail("unknown operation: " + args[0])

func _inspect(path: String) -> void:
	if not path.begins_with("res://") or not ResourceLoader.exists(path, "PackedScene"):
		_fail("scene does not exist: " + path)
		return
	var packed := ResourceLoader.load(path, "PackedScene", ResourceLoader.CACHE_MODE_IGNORE) as PackedScene
	if packed == null:
		_fail("cannot load scene: " + path)
		return
	var root := packed.instantiate()
	if root == null:
		_fail("cannot instantiate scene: " + path)
		return
	print("SCENE ", path)
	_walk(root, 0)
	root.free()
	quit(0)

func _walk(node: Node, depth: int) -> void:
	var detail := ""
	if node is Node2D:
		detail += " position=" + str((node as Node2D).position)
	if node is Label:
		detail += " text=" + str((node as Label).text)
	print("  ".repeat(depth), node.name, " [", node.get_class(), "]", detail)
	for child in node.get_children():
		_walk(child, depth + 1)

func _round_trip() -> void:
	var directory := "res://.automation-fixtures"
	var path := directory + "/round_trip.tscn"
	var absolute_dir := ProjectSettings.globalize_path(directory)
	if DirAccess.make_dir_recursive_absolute(absolute_dir) != OK:
		_fail("could not create fixture directory")
		return
	var root := Node2D.new()
	root.name = "FixtureRoot"
	var child := Label.new()
	child.name = "EditedChild"
	root.add_child(child)
	child.owner = root
	child.position = Vector2(18, 27)
	child.text = "saved through Godot APIs"
	var packed := PackedScene.new()
	var result := packed.pack(root)
	if result == OK:
		result = ResourceSaver.save(packed, path)
	root.free()
	packed = null
	if result != OK:
		_cleanup(path, absolute_dir)
		_fail("scene save failed, error=" + str(result))
		return
	var loaded := ResourceLoader.load(path, "PackedScene", ResourceLoader.CACHE_MODE_IGNORE) as PackedScene
	if loaded == null:
		_cleanup(path, absolute_dir)
		_fail("fresh scene reload failed")
		return
	var copy := loaded.instantiate()
	var edited := copy.get_node_or_null("EditedChild") as Label
	var valid := copy.name == "FixtureRoot" and edited != null and edited.position == Vector2(18, 27) and edited.text == "saved through Godot APIs"
	copy.free()
	_cleanup(path, absolute_dir)
	if not valid:
		_fail("saved hierarchy or changed properties did not persist")
		return
	print("SCENE_AUTOMATION_OK child ownership, position and text persisted")
	quit(0)

func _cleanup(path: String, directory: String) -> void:
	DirAccess.remove_absolute(ProjectSettings.globalize_path(path))
	DirAccess.remove_absolute(directory)

func _fail(message: String) -> void:
	printerr("SCENE_TOOL_FAILED ", message)
	quit(1)

