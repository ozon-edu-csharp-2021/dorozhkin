#!/bin/bash

set -e
run_cmd="dotnet OzonEdu.MerchApi.dll --no-build -v d"

>&2 echo "---- Dry run MerchApi DB Migrations"
dotnet OzonEdu.MerchApi.Migrator.dll --no-build -v d -- --dryrun
>&2 echo "---- Dry run MerchApi DB Migrations complete"

>&2 echo "---- Run MerchApi DB Migrations"
dotnet OzonEdu.MerchApi.Migrator.dll --no-build -v d
>&2 echo "---- Run MerchApi DB Migrations complete"

>&2 echo "MerchApi DB Migrations complete, starting app."
>&2 echo "Run MerchApi: $run_cmd"
exec $run_cmd