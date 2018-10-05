- AppId/ClientId are the same.
- Admin Consent is required for global config (https://www.youtube.com/watch?v=AuIBxxCBkNM)

- refresh_token is used silently to get new access tokens. Instead of grant type authorization_code, you do grant type refresh_token.
-- refresh-token is good for a rolling 2 weeks.
