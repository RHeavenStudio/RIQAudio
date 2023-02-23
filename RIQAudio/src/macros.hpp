#if defined(_MSC_VER)
#define DLLExport extern "C" __declspec(dllexport)
#elif defined(__GNUC__)
#define DLLExport extern "C" __attribute__((visibility("default")))
#else
#define DLLExport extern "C"
#endif