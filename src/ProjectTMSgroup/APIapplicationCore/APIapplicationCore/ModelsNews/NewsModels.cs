using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIapplicationCore.ModelsNews
{
    public class Legacy
    {
        public string xlarge { get; set; }
        public int xlargewidth { get; set; }
        public int xlargeheight { get; set; }
        public string thumbnail { get; set; }
        public int? thumbnailwidth { get; set; }
        public int? thumbnailheight { get; set; }
        public int? widewidth { get; set; }
        public int? wideheight { get; set; }
        public string wide { get; set; }
    }

    public class Multimedia
    {
        public int rank { get; set; }
        public string subtype { get; set; }
        public object caption { get; set; }
        public object credit { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public Legacy legacy { get; set; }
        public string subType { get; set; }
        public string crop_name { get; set; }
    }

    public class Headline
    {
        public string main { get; set; }
        public object kicker { get; set; }
        public object content_kicker { get; set; }
        public string print_headline { get; set; }
        public object name { get; set; }
        public object seo { get; set; }
        public object sub { get; set; }
    }

    public class Keyword
    {
        public string name { get; set; }
        public string value { get; set; }
        public int rank { get; set; }
        public string major { get; set; }
    }

    public class Person
    {
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public object qualifier { get; set; }
        public object title { get; set; }
        public string role { get; set; }
        public string organization { get; set; }
        public int rank { get; set; }
    }

    public class Byline
    {
        public string original { get; set; }
        public IList<Person> person { get; set; }
        public object organization { get; set; }
    }

    public class Doc
    {
        [JsonProperty(PropertyName = "abstract")]
        public string _abstract { get; set; }
        public string web_url { get; set; }
        public string snippet { get; set; }
        public string lead_paragraph { get; set; }
        public string print_section { get; set; }
        public string print_page { get; set; }
        public string source { get; set; }
        public IList<Multimedia> multimedia { get; set; }
        public Headline headline { get; set; }
        public IList<Keyword> keywords { get; set; }
        public DateTime pub_date { get; set; }
        public string document_type { get; set; }
        public string news_desk { get; set; }
        public string section_name { get; set; }
        public string subsection_name { get; set; }
        public Byline byline { get; set; }
        public string type_of_material { get; set; }
        public string _id { get; set; }
        public int word_count { get; set; }
        public string uri { get; set; }
    }

    public class Meta
    {
        public int hits { get; set; }
        public int offset { get; set; }
        public int time { get; set; }
    }

    public class Response
    {
        public IList<Doc> docs { get; set; }
        public Meta meta { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public Response response { get; set; }
    }
}
