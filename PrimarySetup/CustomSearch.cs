using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimarySetup
{
    

    class CustomSearch
    {
        private String displayname;
        private String displaynamevalue;
        private String faviconURL;
        private String faviconURLvalue;
        private String showsearchsuggestions;
        private int showserachsuggestionsvalue;
        private String suggestionsURL;
        private String suggestionsURLvalue;
        private String URL;
        private String URLvalue;

        public CustomSearch(String dn, String dnv, String fURL, String fURLv,String sss,int sssv,String sURL, String sURLv, String url, String URLv) 
        {
            this.displayname = dn;
            this.displaynamevalue = dnv;
            this.faviconURL = fURL;
            this.faviconURLvalue = fURLv;
            this.showsearchsuggestions = sss;
            this.showserachsuggestionsvalue = sssv;
            this.suggestionsURL = sURL;
            this.suggestionsURLvalue = sURLv;
            this.URL = url;
            this.URLvalue = URLv;
        }
        public String CurrentDisplayName
        {
            get { return displayname; }
            set { displayname = value; }
        }
        public String CurrentDisplaynameValue
        {
            get { return displaynamevalue; }
            set { displaynamevalue = value; }
        }
        public String CurrentFaviconURL
        {
            get { return faviconURL; }
            set { faviconURL = value; }
        }
        public String CurrentFaviconURLvalue
        {
            get { return faviconURLvalue; }
            set { faviconURLvalue = value; }
        }
        public String CurrentShowSearchSuggestions
        {
            get { return showsearchsuggestions; }
            set { showsearchsuggestions = value; }
        }
        public int CurrentShowSearchSuggestionsValue
        {
            get { return showserachsuggestionsvalue; }
            set { showserachsuggestionsvalue = value; }
        }
        public String CurrentSuggestionsURL
        {
            get { return suggestionsURL; }
            set { suggestionsURL = value; }
        }
        public String CurrentSuggestionsURLValue
        {
            get { return suggestionsURLvalue; }
            set { suggestionsURLvalue = value; }
        }
        public String CurrentURL
        {
            get { return URL; }
            set { URL = value; }
        }
        public String CurrentURLValue
        {
            get { return URLvalue; }
            set { URLvalue = value; }
        }
    }
}
