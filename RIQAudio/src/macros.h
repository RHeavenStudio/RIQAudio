#if defined(__MACH__)
#define DllExport
#else
#define DllExport __declspec(dllexport)
#endif
