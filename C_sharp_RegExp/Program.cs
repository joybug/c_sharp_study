using System.Text.RegularExpressions;

namespace C_sharp_RegExp
{
    class Program
    {
        static void Main(string[] args)
        {
            string bodyTags = "<p id=\"content\" >" +
                "이미지 태그를 포함한 문자열입니다." +
                "<img src = \"https://image.yes24.com/Goods/119577650/L\" alt=\"Image 1\">" +
                "<p>이미지 태그 안에 또 다른 태그가 있을 수도 있습니다.</p> "+
                "<iframePhoto src = \"https://image.yes24.com/Goods/109001120/L\" alt=\"iframe 2\">"+
                "<div><IMG src = \"https://image.yes24.com/Goods/103113447/L\" alt=\"Image 3\"></div>"+
                "<div><iMg src=\"//image.yes24.com/Goods/103113448/L\" alt=\"Image 4\"></div>"+
                "<div><Img src='//image.yes24.com/Goods/103113449/L' alt=\"Image 5\"></div>"+
                "<input type='button' value=\"여기클릭\" onClick='extractImg()'/></p>"; // 이미지 태그를 여기에 넣으세요
            
            string pattern = @"<(iframePhoto|img)\s+[^>]*>"; // 정규식 패턴

            Regex regex = new Regex(pattern, RegexOptions.ECMAScript|RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(bodyTags);

            foreach (Match match in matches)
            {
               // Console.WriteLine(match.Value);
               string repText = Regex.Replace(match.Value, @"src\s*=\s*[""']([^""']+)[""']", "src=\"https:$1\"", RegexOptions.IgnoreCase);
                
               Console.WriteLine(repText+"\n");
            }
            

        }
    }
}