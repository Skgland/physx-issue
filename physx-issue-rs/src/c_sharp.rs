use std::mem::offset_of;

#[repr(C)]
#[allow(non_snake_case)]

struct LayoutInfo {
    alignment: usize,
    size: usize,
    controller_offset: usize,
    worldPos_offset: usize,
    worldNormal_offset: usize,
    dir_offset: usize,
    length_offset: usize,
    structgen_pad0_offset: usize,
    shape_offset: usize,
    actor_offset: usize,
    triangleIndex_offset: usize,
    structgen_pad1_offset: usize,
}

#[no_mangle]
extern "C" fn determin_layout() -> LayoutInfo {
    let layout = core::alloc::Layout::new::<physx_sys::PxControllerShapeHit>();

    LayoutInfo {
        alignment: layout.align(),
        size: layout.size(),
        controller_offset: offset_of!(physx_sys::PxControllerShapeHit, controller),
        worldPos_offset: offset_of!(physx_sys::PxControllerShapeHit, worldPos),
        worldNormal_offset: offset_of!(physx_sys::PxControllerShapeHit, worldNormal),
        dir_offset: offset_of!(physx_sys::PxControllerShapeHit, dir),
        length_offset: offset_of!(physx_sys::PxControllerShapeHit, length),
        structgen_pad0_offset: offset_of!(physx_sys::PxControllerShapeHit, structgen_pad0),
        shape_offset: offset_of!(physx_sys::PxControllerShapeHit, shape),
        actor_offset: offset_of!(physx_sys::PxControllerShapeHit, actor),
        triangleIndex_offset: offset_of!(physx_sys::PxControllerShapeHit, triangleIndex),
        structgen_pad1_offset: offset_of!(physx_sys::PxControllerShapeHit, structgen_pad1),
    }
}
