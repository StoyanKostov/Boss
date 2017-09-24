const CleanWebpackPlugin = require('clean-webpack-plugin');
const webpack = require('webpack');

module.exports = {
    context: __dirname + '/wwwroot/app/src',
    entry: {
        app: './app.js',
        //vendor: [
        //    '../../lib/jquery',
        //    '../../lib/angular',
        //    '../../lib/angular-ui-router/release/angular-ui-router.js',
        //    '../../lib/bootstrap'
        //]
    },
    output: {
        path: __dirname + '/wwwroot/app/build',
        filename: '[name].js',
        //filename: '[name].[hash:8].js',
        //sourceMapFilename: '[name].[hash:8].map',
        //chunkFilename: '[id].[hash:8].js'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: "babel-loader",
                query: {
                    // plugins: ['transform-runtime'],
                    presets: ['es2015']
                }
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin([__dirname + '/wwwroot/app/build'], {
            verbose: true,
            dry: false
        })
    ]
}; 