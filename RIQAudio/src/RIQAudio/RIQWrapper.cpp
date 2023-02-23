#include "../macros.hpp"
#include "riqaudio.hpp"

DLLExport RIQAudio* CreateRIQAudio()
{
	return new RIQAudio();
}

DLLExport bool DeleteRIQAudio(RIQAudio* riq)
{
	if (riq != NULL)
		delete riq;
	return riq == nullptr;
}