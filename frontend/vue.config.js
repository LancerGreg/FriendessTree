module.exports = {
  transpileDependencies: [
    'vuetify'
  ],

  configureWebpack: {
    optimization: {
      splitChunks: {
        minSize: 10000,
        maxSize: 250000,
      }
    },
  },

  outputDir: "[PATH TO WWWROOOT]"
}
