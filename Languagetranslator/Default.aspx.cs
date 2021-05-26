using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Translate();
    }
    public void Translate(string textvalue,string to)
    {
        string appId = "A70C584051881A30549986E65FF4B92B95B353A5";//go to http://msdn.microsoft.com/en-us/library/ff512386.aspx to obtain AppId.
       // string textvalue = "Translate this for me";
        string from = "id";
        //string to = "es";

        string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId=" + appId +"&text=" + textvalue + "&from=" + from + "&to=" + to;

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

        WebResponse response = null;
        try
        {
            response = httpWebRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                string translation = (string)dcs.ReadObject(stream);
                
                ltTranslatetxt.Text="<b>The translated text is: </b>'" + translation + "'.";
            }
        }
        catch (WebException e)
        {
            ProcessWebException(e, "Failed to translate");
        }
        finally
        {
            if (response != null)
            {
                response.Close();
                response = null;
            }
        }
    }

    private void ProcessWebException(WebException e, string message)
    {
        ltTranslatetxt.Text=message+" : :"+ e.ToString();

        // Obtain detailed error information
        string strResponse = string.Empty;
        using (HttpWebResponse response = (HttpWebResponse)e.Response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                {
                    strResponse = sr.ReadToEnd();
                }
            }
        }
        ltTranslatetxt.Text="Http status code="+ e.Status+" ,error message="+ strResponse;
    }

    protected void btnTranslate_Click(object sender, EventArgs e)
    {
        Translate(txtValue.Text,ddlanguage.SelectedItem.Value.ToString());
    }
    //public void languageCode()
    //{           
    //            'ALBANIAN' : 'sq',
               
    //            'ARMENIAN' : 'hy',
             
    //            'BASQUE' : 'eu',
               
    //            'BURMESE' : 'my',
    //            'CATALAN' : 'ca',
    //            'CHEROKEE' : 'chr',
    //            'CHINESE' : 'zh',
    //            'CHINESE_SIMPLIFIED' : 'zh-CN',
    //            'CHINESE_TRADITIONAL' : 'zh-TW',
    //            'CORSICAN' : 'co',
    //            'CROATIAN' : 'hr',
    //            'CZECH' : 'cs',
    //            'DANISH' : 'da',
    //            'DHIVEHI' : 'dv',
    //            'DUTCH': 'nl',  
    //            'ENGLISH' : 'en',
    //            'ESPERANTO' : 'eo',
    //            'ESTONIAN' : 'et',
    //            'FAROESE' : 'fo',
    //            'FILIPINO' : 'tl',
    //            'FINNISH' : 'fi',
    //            'FRENCH' : 'fr',
    //            'FRISIAN' : 'fy',
    //            'GALICIAN' : 'gl',
    //            'GEORGIAN' : 'ka',
    //            'GERMAN' : 'de',
    //            'GREEK' : 'el',
    //            'GUJARATI' : 'gu',
    //            'HAITIAN_CREOLE' : 'ht',
    //            'HEBREW' : 'iw',
    //            'HINDI' : 'hi',
    //            'HUNGARIAN' : 'hu',
    //            'ICELANDIC' : 'is',
    //            'INDONESIAN' : 'id',
    //            'INUKTITUT' : 'iu',
    //            'IRISH' : 'ga',
    //            'ITALIAN' : 'it',
    //            'JAPANESE' : 'ja',
    //            'JAVANESE' : 'jw',
    //            'KANNADA' : 'kn',
    //            'KAZAKH' : 'kk',
    //            'KHMER' : 'km',
    //            'KOREAN' : 'ko',
    //            'KURDISH': 'ku',
    //            'KYRGYZ': 'ky',
    //            'LAO' : 'lo',
    //            'LATIN' : 'la',
    //            'LATVIAN' : 'lv',
    //            'LITHUANIAN' : 'lt',
    //            'LUXEMBOURGISH' : 'lb',
    //            'MACEDONIAN' : 'mk',
    //            'MALAY' : 'ms',
    //            'MALAYALAM' : 'ml',
    //            'MALTESE' : 'mt',
    //            'MAORI' : 'mi',
    //            'MARATHI' : 'mr',
    //            'MONGOLIAN' : 'mn',
    //            'NEPALI' : 'ne',
    //            'NORWEGIAN' : 'no',
    //            'OCCITAN' : 'oc',
    //            'ORIYA' : 'or',
    //            'PASHTO' : 'ps',
    //            'PERSIAN' : 'fa',
    //            'POLISH' : 'pl',
    //            'PORTUGUESE' : 'pt',
    //            'PORTUGUESE_PORTUGAL' : 'pt-PT',
    //            'PUNJABI' : 'pa',
    //            'QUECHUA' : 'qu',
    //            'ROMANIAN' : 'ro',
    //            'RUSSIAN' : 'ru',
    //            'SANSKRIT' : 'sa',
    //            'SCOTS_GAELIC' : 'gd',
    //            'SERBIAN' : 'sr',
    //            'SINDHI' : 'sd',
    //            'SINHALESE' : 'si',
    //            'SLOVAK' : 'sk',
    //            'SLOVENIAN' : 'sl',
    //            'SPANISH' : 'es',
    //            'SUNDANESE' : 'su',
    //            'SWAHILI' : 'sw',
    //            'SWEDISH' : 'sv',
    //            'SYRIAC' : 'syr',
    //            'TAJIK' : 'tg',
    //            'TAMIL' : 'ta',
    //            'TATAR' : 'tt',
    //            'TELUGU' : 'te',
    //            'THAI' : 'th',
    //            'TIBETAN' : 'bo',
    //            'TONGA' : 'to',
    //            'TURKISH' : 'tr',
    //            'UKRAINIAN' : 'uk',
    //            'URDU' : 'ur',
    //            'UZBEK' : 'uz',
    //            'UIGHUR' : 'ug',
    //            'VIETNAMESE' : 'vi',
    //            'WELSH' : 'cy',
    //            'YIDDISH' : 'yi',
    //            'YORUBA' : 'yo',
    //            'UNKNOWN' : ''
    //}
    string lng=@"ca,ca-es,da,da-dk,de,de-de,
            en
            en-au
            en-ca
            en-gb
            en-in
            en-us
            es
            es-es
            es-mx
            fi
            fi-fi
            fr
            fr-ca
            fr-fr
            it
            it-it
            ja
            ja-jp
            ko
            ko-kr
            nb-no
            nl
            nl-nl
            no
            pl
            pl-pl
            pt
            pt-br
            pt-pt
            ru
            ru-ru
            sv
            sv-se
            zh-chs
            zh-cht
            zh-cn
            zh-hk
            zh-tw";
}
