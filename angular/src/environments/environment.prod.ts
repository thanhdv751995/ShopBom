import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ShopBom',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44318',
    redirectUri: baseUrl,
    clientId: 'ShopBom_App',
    responseType: 'code',
    scope: 'offline_access ShopBom',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44318',
      rootNamespace: 'ShopBom',
    },
  },
} as Environment;
