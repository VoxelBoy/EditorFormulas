# Editor Fomulas

All community submitted Editor Formulas are gathered here.

A "Formula" is a single static method that has no return value but can have zero to many parameters.

## Writing Formulas

Here is a simple Formula template:  
```
using UnityEngine;

namespace EditorFormulas
{
	public static partial class Formulas
	{
		public static void AddOneAndLog (int number)
		{
			Debug.Log(number + 1);
		}
	}
}
```

When loaded in Editor Formulas Window, this Formula will show up like this:

<img width="302" alt="Add One Formula" src="https://cloud.githubusercontent.com/assets/433535/16903904/9c23a6b8-4c93-11e6-852d-d5ea4fd16467.png">

There are several hard requirements for how Formulas must be written:  
* The method must be public and static
* The method must be inside a partial Formulas class
* The class must be inside the EditorFormulas namespace
* The name of the file containing the formula must be exactly the same as the method name
* The method name must be unique among all other methods

A FormulaTemplate.cs file is provided in the [Editor Formulas Window repository](https://github.com/VoxelBoy/EditorFormulasWindow) to make it easier to create a new formula that meets these requirements.

If you're working on a complex Formula and you're having trouble implementing everything within a single method, you can use additional *private static* methods, *static* variables, and even *nested classes*.  
However, as a best-practice, you should suffix your additional member names with your Formula name to ensure that they are unique among all members written in all other Formulas submitted here. This is necessary since they're all compiled under the same Formulas class.

## Supported parameter types

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
