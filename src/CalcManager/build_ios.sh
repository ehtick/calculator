#!/bin/bash

xcrun -sdk iphoneos clang \
    -x c++ \
    -arch arm64 \
	-miphoneos-version-min=10.0 \
    -std=c++1z \
    -stdlib=libc++ \
    -c \
	CEngine/*.cpp RatPack/*.cpp *.cpp -I.  

mkdir bin
mkdir bin/arm64

libtool \
    -static \
    *.o \
    -o ../Calculator.Mobile/iOS/NativeReferences/arm64/libCalcManager.a

rm *.o

xcrun -sdk iphonesimulator clang \
    -x c++ \
    -arch x86_64 \
    -std=c++1z \
    -stdlib=libc++ \
    -c \
	CEngine/*.cpp RatPack/*.cpp *.cpp -I.  

mkdir bin/x86_64

libtool \
    -static \
    *.o \
    -o ../Calculator.Mobile/iOS/NativeReferences/x86_64/libCalcManager.a

rm *.o

