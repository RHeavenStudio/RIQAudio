#include "riqpch.h"

#include "RIQAudio.hpp"

#include "RIQAudioDevice.hpp"

DLLExport RIQAudioDevice* CreateRIQAudioDevice()
{
	return new RIQAudioDevice();
}

DLLExport void DeleteRIQAudioDevice(RIQAudioDevice* riq)
{
	delete riq;
}