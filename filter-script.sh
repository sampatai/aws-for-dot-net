#!/bin/bash
# Filter script to remove AWS credentials from BucketController.cs
FILE="Cred.Demo/Cred.Demo/Controllers/BucketController.cs"
if [ -f "$FILE" ]; then
	# Remove lines containing AWS keys
	sed -i '/AKIA[A-Z0-9]\{16\}/d' "$FILE"
fi
