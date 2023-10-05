#!/bin/bash
both >& outfile #2021-07-09 Sending Both Output and Error Messages to the Same File
both &< outfile #2021-07-09 Sending Both Output and Error Messages to the Same File
both > outfile 2>&1 #2021-07-09 Sending Both Output and Error Messages to the Same File
