const path = require("path");
const env = process.env.NODE_ENV || "development";

const config = require('./config.json');
let envConfig = config[env];
envConfig.root = path.normalize(__dirname + "/..");
envConfig.app = { name : "simplesjustica-web" };
envConfig.port = process.env.PORT || envConfig.port;

module.exports = envConfig;
