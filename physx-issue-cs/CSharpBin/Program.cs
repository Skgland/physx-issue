// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using CsBindgen;


var rust_layout = NativeBindings.DeterminLayoutRust();
var cs_layout = DeterminLayoutCs();

bool layout_matches = true;

if (cs_layout.size != rust_layout.size)
{
    Console.WriteLine($"Layout Size Missmatch: {cs_layout.size} vs. {rust_layout.size}");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Size Matches");
}

if (cs_layout.alignment != rust_layout.alignment)
{
    Console.WriteLine($"Layout Alignment Missmatch: {cs_layout.alignment} vs {rust_layout.alignment}");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Alignment Matches");
}


if (cs_layout.controller_offset != rust_layout.controller_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (controller):{cs_layout.controller_offset} vs. {rust_layout.controller_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (controller)");
}


if (cs_layout.worldPos_offset != rust_layout.worldPos_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (worldPos):{cs_layout.worldPos_offset} vs. {rust_layout.worldPos_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (worldPos)");
}

if (cs_layout.worldNormal_offset != rust_layout.worldNormal_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (worldNormal):{cs_layout.worldNormal_offset} vs. {rust_layout.worldNormal_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (worldNormal)");
}

if (cs_layout.dir_offset != rust_layout.dir_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (dir):{cs_layout.dir_offset} vs. {rust_layout.dir_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (dir)");
}

if (cs_layout.length_offset != rust_layout.length_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (length):{cs_layout.length_offset} vs. {rust_layout.length_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (length)");
}

if (cs_layout.structgen_pad0_offset != rust_layout.structgen_pad0_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (structgen_pad0):{cs_layout.structgen_pad0_offset} vs. {rust_layout.structgen_pad0_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (structgen_pad0)");
}

if (cs_layout.shape_offset != rust_layout.shape_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (shape):{cs_layout.shape_offset} vs. {rust_layout.shape_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (shape)");
}

if (cs_layout.actor_offset != rust_layout.actor_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (actor):{cs_layout.actor_offset} vs. {rust_layout.actor_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (actor)");
}

if (cs_layout.triangleIndex_offset != rust_layout.triangleIndex_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (triangleIndex):{cs_layout.triangleIndex_offset} vs. {rust_layout.triangleIndex_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (triangleIndex)");
}

if (cs_layout.structgen_pad1_offset != rust_layout.structgen_pad1_offset)
{
    Console.WriteLine($"Layout Offset Missmatch (structgen_pad1):{cs_layout.structgen_pad1_offset} vs. {rust_layout.structgen_pad1_offset} ");
    layout_matches = false;
}
else
{
    Console.WriteLine("Layout Offset Matches (structgen_pad1)");
}

if (!layout_matches)
{
    throw new Exception("Layout Missmatch between C# and Rust!");
}


LayoutInfo DeterminLayoutCs()
{
    return new LayoutInfo
    {
        size = (nuint)Marshal.SizeOf<PxControllerShapeHit>(),
        alignment = (nuint)AlignmentOf<PxControllerShapeHit>(),
        controller_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.controller)),
        worldPos_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.worldPos)),
        worldNormal_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.worldNormal)),
        dir_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.dir)),
        length_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.length)),
        structgen_pad0_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.structgen_pad0)),
        shape_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.shape)),
        actor_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.actor)),
        triangleIndex_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.triangleIndex)),
        structgen_pad1_offset = (nuint)Marshal.OffsetOf<PxControllerShapeHit>(nameof(PxControllerShapeHit.structgen_pad1)),

    };
}

#pragma warning disable CS0649
/* Start https://stackoverflow.com/a/77212312/7847252 */

nint AlignmentOf<T>() where T : unmanaged
{
    return Marshal.OffsetOf<AlignmentHelper<T>>(nameof(AlignmentHelper<T>.Target));
}
internal struct AlignmentHelper<T> where T : unmanaged
{
    public byte Padding;
    public T Target;
}

/* End  https://stackoverflow.com/a/77212312/7847252 */
#pragma warning restore CS0649