const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:38466';

const context =  [
  "/api/v1/spells",
  "/api/v1/classes/archetypes",
  "/api/v1/classes",
  "/api/v1/sources",
  "/api/v1/authenticate",
  "/api/v1/register",
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
