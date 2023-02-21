workspace "RIQAudio"
    
    configurations
    {
        "Debug",
        "Release"
    }

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

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

    includedirs
    {
        "%{prj.name}/vendor/miniaudio/"
    }

    cdialect "Default"
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

    filter "configurations:Release"
        optimize "On"