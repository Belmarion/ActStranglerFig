namespace UniSabana.ApiLibreriaKmlMono
{
    using System;
    public class Resource
    {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        internal Resource() { }
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UniSabana.ApiLibreriaKmlMono.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }
        /// <summary>
        ///   Busca una cadena traducida similar a Configurar en Resource.resx.
        /// </summary>
        public static string Description
        {
            get
            {
                return ResourceManager.GetString("Description", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Configurar en Resource.resx.
        /// </summary>
        public static string DocumentTitle
        {
            get
            {
                return ResourceManager.GetString("DocumentTitle", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a &lt;div class=&apos;cont-sod&apos;&gt;    &lt;div id=&apos;img-cont&apos;&gt;&lt;img src=&apos;data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAK4AAACJCAYAAAC1pQNgAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAADnQAAA50BvNxDqgAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAABAFSURBVHic7d3bj5vHecfx7/PMe+CZu9KeRXF3JVmSpaRuGqANChT1RVOktes4PkRRYjmOUyR20qRtLlynSFCjQdzmrmjRP6B/QBPkrjB6lys3jW0gduSDLEuWFK0ku9kl98DT+04vuBtbEkmduOS+9HyAvdDiFTkkfzuceWbe9wXHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHcRzHaZNhNyDhdHp6Ou37fqiq9rYeQNV6nrdx6tSper8bN8q8YTcgyfbsOTzu+40Tgv1 [resto de la cadena truncado]&quot;;.
        /// </summary>
        public static string HeadContent
        {
            get
            {
                return ResourceManager.GetString("HeadContent", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a Configurar en Resource.resx.
        /// </summary>
        public static string Title
        {
            get
            {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }

        /// <summary>
        ///   Busca una cadena traducida similar a https://www.homecenter.com.co/homecenter-co/.
        /// </summary>
        public static string UrlHome
        {
            get
            {
                return ResourceManager.GetString("UrlHome", resourceCulture);
            }
        }
    }
}
