wildcard=

# Make does not offer a recursive wildcard function, so here's one:
#rwildcard=$(wildcard $1$2) $(foreach d,$(wildcard $1*),$(call rwildcard,$d/,$2))

# How to recursively find all files with the same name in a given folder
#ALL_INDEX_HTMLS := $(call rwildcard,foo/,index.html)

# How to recursively find all files that match a pattern
#ALL_HTMLS := $(call rwildcard,foo/,*.html)

#SOURCES = $(ProcessLogic/*.cpp)

all: AlphabetSequence.obj

AlphabetSequence.obj: ProcessLogic/AlphabetSequence.cpp
 cl /EHsc /Fo /LD /LDd ProcessLogic/AlphabetSequence.cpp
