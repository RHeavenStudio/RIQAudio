workspace "RIQAudio"
    
    Configurations
    {
        "Debug",
        "Release"
    }

outputdir = "%{cfg.buildcfg}-${cfg.system}-%{cfg.architecture}";

project "RIQAudio"
    location "RIQAudio"
    kind "SharedLib"
    language "C"

    targetdir ("bin/" .. outputdir .. "/%{prj.name}")
    objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

    files
    {
        "%{prj.name}/src/**.h",
        "%{prj.name}/src/**.c",
    }

    include 
    {
        "%{prj.name}/vendor"
    }

    cdialect "C17"
    staticruntime "On"

    defines
    {
        "_CRT_SECURE_NO_WARNINGS"
    }

    postbuildcommands
    {
        ("{COPY} %{cfg.buildtarget.relpath} ../RIQAudioUnity/Assets/RIQAudioSharp/bin")
    }

    filter "configurations:Debug"
        symbols "On"

    filter "configuration:Release"
        optimize "On"