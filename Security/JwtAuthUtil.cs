using Jose;
using POSSystemApi.Models;
using System.Text;

public class JwtAuthUtil
{
    public string GenerateToken(User user)
    {
        string secret = "jwtauthapp";//加解密的key,如果不一樣會無法成功解密
        Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
        claim.Add("Account", user.account);
        claim.Add("Name", user.name);
        claim.Add("Exp", DateTime.Now.AddSeconds(Convert.ToInt32("1000")).ToString());//Token 時效設定100秒
        var payload = claim;
        var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
        return token;
    }
}
