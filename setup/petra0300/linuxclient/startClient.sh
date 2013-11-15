#!/bin/bash
. /opt/mono-openpetra/env.sh
cd bin30
if [ ! -f ../etc30/publickey.xml ]
then
  cp ../etc30/publickey-sample.xml ../etc30/publickey.xml
fi
mono PetraClient.exe -C:../etc30/PetraClientRemote.config &
cd ..
