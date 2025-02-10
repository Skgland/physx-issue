use std::{error::Error, time::Duration};

fn main() -> Result<(), Box<dyn Error>> {
    csbindgen::Builder::default()
        .input_extern_file("src/c_sharp.rs")
        .csharp_dll_name("physx_issue_rs")
        .csharp_class_accessibility("public")
        .generate_csharp_file(concat!(
            env!("CARGO_MANIFEST_DIR"),
            "/dotnet/NativeMethods.g.cs"
        ))?;

    let source = if build::target() == "x86_64-pc-windows-msvc" {
        "vendor/physx-sys/src/generated/x86_64-pc-windows-msvc/structgen.rs"
    } else if build::cargo_cfg_unix() {
        "vendor/physx-sys/src/generated/unix/structgen.rs"
    } else {
        panic!()
    };

    csbindgen::Builder::default()
        .input_extern_file(source)
        .csharp_dll_name("physx_lib")
        .always_included_types(["PxControllerShapeHit", "PxController"])
        .generate_csharp_file(concat!(
            env!("CARGO_MANIFEST_DIR"),
            "/dotnet/NativeMethodsPhysx.g.cs"
        ))?;

    std::thread::sleep(Duration::from_secs(1));

    Ok(())
}
