"use strict";

module.exports = {
    entry: "./Main.jsx",
    output: {
        filename: "bundle.js"
    },
    module: {
        loaders: [
            {
                test: /\.jsx?$/,
                loader: "babel-loader",                
                exclude: /node_modules/,
                query: { presets: ["es2015", "react"] }                
            }
        ]
    },
    devtool: "source-map",
    resolve: {
        extensions: ['.js', '.jsx']
    }
};