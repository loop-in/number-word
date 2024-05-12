#!/bin/bash

# Set the base URL for the WebAPI project
baseURL="http://localhost:5026"

function sendRequest() {
    local param="$1"
    echo "Making GET request to $baseURL/converters/moneys?value=$param"
    local response=$(curl -s -w '' -X GET "$baseURL/converters/moneys?value=$param")

    # Output the response
    echo "Response:"
    echo "$response\n"
}

# Get input
while true; do
    echo "Please enter the value: (Enter x to exit)"

    read input

    case $input in
        x|X)
            echo "Exiting...\n"
            exit
            ;;
        *)
            sendRequest "$input"
            ;;
    esac
done
