Torch PreFab readme

This torch prefab contains only a few parts.
It contains a base fbx model, a point light, and a smoke system gameobject
that contains a generatesmoke script.
The generatesmoke script attempts to instantiate smoke particles from
a resources/JD/smoke folder. If the fbx resources can not be found
it creates a primitive sphere gameobject instead.
