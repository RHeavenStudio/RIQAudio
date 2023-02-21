cmake_minimum_required(VERSION 3.25.2)

project(RIQAudio)

file(GLOB SOURCES src/*.c src/*.cpp src/*.h src/*.hpp)

include_directories(${CMAKE_CURRENT_SOURCE_DIR}/vendor)

add_library(RIQAudio SHARED ${SOURCES})
