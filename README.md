# PluginFramework

To test this send below request body from postman or swagger



{
    "effects": [
        {
            "pluginName": "DummyPlugin",
            "parameters": {
                "param1": "value1",
                "param2": "value2"
            }
        },
        {
            "pluginName": "DummyPlugin",
            "parameters": {
                "param1": "value3",
                "param2": "value4"
            }
        }
    ]
}
