using Jose;
using POSSystemApi.Models;
using System.Text;

public class JwtAuthUtil
{
    public static string GenerateToken(User user)
    {
        string secret = "jwtauthapp";//加解密的key
        Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
        claim.Add("Account", user.account);
        claim.Add("Name", user.name);
        claim.Add("Exp", DateTime.Now.AddSeconds(Convert.ToInt32("1000")).ToString());//Token 時效設定100秒
        var payload = claim;
        var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
        return token;
    }

    public static bool VerifyToken(string token){
        string secret = "jwtauthapp";//加解密的key
        try {
            //解密後會回傳Json格式的物件(即加密前的資料)
            var jwtObject = Jose.JWT.Decode<Dictionary<string, Object>>(
            token,
            Encoding.UTF8.GetBytes(secret),
            JwsAlgorithm.HS512);
            if (IsTokenExpired(jwtObject["Exp"].ToString()))
            {
                return false;
            }
            return true;
            
        }catch{
            return false;
        }
        
    }

    //驗證token時效
    public static bool IsTokenExpired(string dateTime)
    {
        return Convert.ToDateTime(dateTime) < DateTime.Now;
    }
 
}
