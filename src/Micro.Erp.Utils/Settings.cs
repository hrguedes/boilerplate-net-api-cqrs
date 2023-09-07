namespace Micro.Erp.Utils;

public static class Settings
{
    public static string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    
    #region Redis
    public static string RedisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING") ?? "SET_HERE_LOCAL_DEVELOPMENT";
    public static string[] RedisDatabases =
    {
        "BOILERPLATE_REDIS_DB"
    };
    public static string KeepAlive = Environment.GetEnvironmentVariable("KEEP_ALIVE") ?? "10";
    public static string ResponseTimeout = Environment.GetEnvironmentVariable("RESPONSE_TIMEOUT") ?? "10";
    public static string ConnectTimeout = Environment.GetEnvironmentVariable("CONNECT_TIMEOUT") ?? "10";
    public static string KeyPrefixo = Environment.GetEnvironmentVariable("KEY_PREFIXO") ?? "BOILERPLATE_CACHE";
    #endregion

    #region Chaves
    public static string JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "fedaf7d8863b48e197b9287d492b708e";
    public static string EncryptionKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY") ?? "fedaf7d8863b48e197b9287d492b908e";
    public static string SenhaPadrao = Environment.GetEnvironmentVariable("SENHA_PADRAO") ?? "ADMIN123";
    #endregion

    #region Configuracoes de Sessao
    public static string TempoSessaoHoras = Environment.GetEnvironmentVariable("TEMPO_SESSAO_HORAS") ?? "5";
    #endregion
}