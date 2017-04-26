using System;

namespace einfache_refactorings
{
    public class FormattingService
    {
        private Func<DateTime> now;

        internal FormattingService(Func<DateTime> now) {
            this.now = now;
        }

        public FormattingService() : this(() => DateTime.Now) {
        }

        public string Format(string message) {
            return now() + ": " + message;
        }

        public string Format(Adresse adresse, string vorname, string nachname) {
            return $"{vorname} {nachname}, {adresse.Strasse} {adresse.Hn}, {adresse.Plz} {adresse.Ort}";
        }

        public class Adresse
        {
            private string strasse;
            private string hn;
            private string plz;
            private string ort;

            public Adresse(string strasse, string hn, string plz, string ort) {
                this.strasse = strasse;
                this.hn = hn;
                this.plz = plz;
                this.ort = ort;
            }

            public string Strasse {
                get { return strasse; }
            }

            public string Hn {
                get { return hn; }
            }

            public string Plz {
                get { return plz; }
            }

            public string Ort {
                get { return ort; }
            }
        }
    }
}