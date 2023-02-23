#include "riqpch.h"

#include "RIQAudio.hpp"

#include "RIQAudioDevice.hpp"

DLLExport RIQAudioDevice* CreateRIQAudio()
{
	return new RIQAudioDevice();
}

DLLExport void DeleteRIQAudio(RIQAudioDevice* riq)
{
	delete riq;
}