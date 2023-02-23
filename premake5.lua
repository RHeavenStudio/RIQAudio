workspace "RIQAudio"
    architecture "x86_64"

    configurations
    {
        "Debug",
        "Release"
    }

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "RIQAudio"
    location "RIQAudio"
    kind "SharedLib"
    language "C++"

    cppdialect "Default"
    staticruntime "On"

    pchheader "riqpch.h"
    pchsource "%{prj.name}/src/riqpch.cpp"

    targetdir ("RIQAudioTest/")
    objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

    files
    {
        "%{prj.name}/src/**.h",
        "%{prj.name}/src/**.c",
        "%{prj.name}/src/**.hpp",
        "%{prj.name}/src/**.cpp",
    }

    includedirs
    {
        "%{prj.name}/src",
        "%{prj.name}/src/**",
        "%{prj.name}/vendor"
    }

    defines
    {
        "_CRT_SECURE_NO_WARNINGS"
    }

    filter "configurations:Debug"
        symbols "On"

    filter "configurations:Release"
        optimize "On"

project "RIQAudioTest"
    location "RIQAudioTest"
    kind "ConsoleApp"
    language "C#"

    files
    {
        "%{prj.name}/src/**.cs",
        "%{prj.name}/**.dll"
    }