#include "../macros.hpp"
#include "riqaudio.hpp"

#include <stdlib.h>

DLLExport RIQAudio* CreateRIQAudio()
{
	return new RIQAudio();
}

DLLExport void DeleteRIQAudio(RIQAudio* riq)
{
	delete riq;
}