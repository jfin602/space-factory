extends SceneTree

# Developer-only visual evidence helper. Run after import/build:
# godot --path game --script res://dev/capture_scene.gd -- res://scenes/asset_preview.tscn /absolute/output.png

func _initialize() -> void:
	call_deferred("_capture")

func _capture() -> void:
	var args := OS.get_cmdline_user_args()
	if args.size() != 2:
		push_error("CAPTURE_FAILED expected scene path and absolute PNG path")
		quit(2)
		return
	var packed := load(args[0]) as PackedScene
	if packed == null:
		push_error("CAPTURE_FAILED scene could not load: " + args[0])
		quit(2)
		return
	var scene := packed.instantiate()
	root.add_child(scene)
	current_scene = scene
	await process_frame
	await process_frame
	await create_timer(0.1).timeout
	var result := root.get_texture().get_image().save_png(args[1])
	if result != OK:
		push_error("CAPTURE_FAILED could not write PNG")
		quit(2)
		return
	print("CAPTURE_OK " + args[1])
	quit(0)
