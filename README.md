## Editor Formulas

All community submitted Editor Formulas are gathered here.

A "Formula" is a single static method that has no return value but can have zero to many parameters.

### Writing Formulas

Here is a simple Formula template:  
```
using UnityEngine;

namespace EditorFormulas.Formulas
{
	public static class AddOneAndLog
	{
		[FormulaAttribute ("Add One and Log", "Adds one to the given number and prints it out", "GenericAuthor")]
		public static void Run (int number)
		{
			Debug.Log(number + 1);
		}
	}
}
```

When loaded in Editor Formulas Window, this Formula will show up like this:

<img width="302" alt="Add One Formula" src="https://cloud.githubusercontent.com/assets/433535/16903904/9c23a6b8-4c93-11e6-852d-d5ea4fd16467.png">

There are several hard requirements for how Formulas must be written:  
* The name of the file and the class must match exactly.
* The name must must be unique among all other formulas.
* A FormulaAttribute must be added to the entry method for the formula.
* The entry method must be public and static.
* The class should be inside the EditorFormulas.Formulas namespace.

A FormulaTemplate.cs file is provided in the [Editor Formulas Window repository](https://github.com/VoxelBoy/EditorFormulasWindow) to make it easier to create a new formula that meets these requirements.

If you're working on a complex Formula and you're having trouble implementing everything within a single method, you can use additional *private static* methods, *static* variables, and even *nested classes*.

### Supported parameter types

* Int
* Float
* String
* Bool
* Rect
* RectOffset
* Vector2
* Vector3
* Vector4
* Color
* UnityEngine.Object
* Enum
* LayerMask
* More to come soon

### Submitting Formulas
1. Create a copy of the FormulaTemplate.cs file that you can find in the [Editor Formulas Window repository](https://github.com/VoxelBoy/EditorFormulasWindow).
2. Choose a unique name for your Formula that's descriptive of what it does. Rename the file and the class with the CamelCase version of your Formula name.
3. Modify the FormulaAttribute on the already existing Run method to pass it the formula name, tooltip, and author name.
4. Fork this repository and submit your Formula as a pull request.
5. Your Formula will be quickly reviewed. If it's not directly accepted, you will be contacted to correct any issues found.
