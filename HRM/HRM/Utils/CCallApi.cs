using CoreLib.Commons;
using CoreLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace HRM.Utils
{
    public static class CCallApi
    {
        #region snippet_HttpClient

        public static HttpClient client = new HttpClient();

        private const string API_LINK = CommonConstants.API_LINK;


        #endregion snippet_HttpClient

        private static void Unit()
        {
            try
            {
                client.BaseAddress = new Uri(API_LINK);
                client.Timeout = TimeSpan.FromMinutes(30); // Thoi gian time out
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }

        // Call api Post Method
        public static async Task<CResult> PostTemplateAsync(Object obj, string LinkAPI)
        {
            Unit();
            CResult cResult = new CResult();
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(LinkAPI, obj);
                if (response.IsSuccessStatusCode)
                {
                    cResult = await response.Content.ReadAsAsync<CResult>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return cResult;
        }

        // Call api Put Method
        public static async Task<CResult> PutTemplateAsync(Object temp, string LinkAPI)
        {
            Unit();
            CResult cResult = new CResult();
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(LinkAPI, temp);
                if (response.IsSuccessStatusCode)
                {
                    cResult = await response.Content.ReadAsAsync<CResult>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            return cResult;
        }

        // Call api Delete Method
        public static async Task<CResult> DeleteTemplateAsync(string LinkAPI)
        {
            Unit();
            CResult cResult = new CResult();

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(LinkAPI);
                if (response.IsSuccessStatusCode)
                {
                    cResult = await response.Content.ReadAsAsync<CResult>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            return cResult;
        }

        // Call api Get Method (Search)
        public static async Task<Object> SearchTemplateAsync(string LinkAPI)
        {
            Unit();
            Object obj = new Object();
            try
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI);

                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<Object>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return obj;
        }

        // Call api Get Method (Get all)
        public static async Task<List<Object>> GetTemplateAsync(string LinkAPI)
        {
            Unit();
            List<Object> obj = new List<Object>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI);

                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<List<Object>>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return obj;
        }

        /// <summary>
        /// GetDataTableTemplateAsync
        /// </summary>
        /// <param name="LinkAPI"></param>
        /// <returns>Datatable</returns>
        public static async Task<DataTable> GetDataTableTemplateAsync(string LinkAPI)
        {
            Unit();

            try
            {
                var response = await client.GetAsync(LinkAPI);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<DataTable>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return new DataTable();
        }

        public static async Task<CResult> GetCResultTemplateAsync(string LinkAPI)
        {
            Unit();
            CResult obj = new CResult();
            try
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI);

                if (response.IsSuccessStatusCode)
                {
                    obj = await response.Content.ReadAsAsync<CResult>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return obj;
        }

        public static async Task<string> GetStringTemplateAsync(string LinkAPI)
        {
            Unit();

            try
            {
                var response = await client.GetAsync(LinkAPI);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    //return (await response.Content.ReadAsStringAsync(string));
                    return await response.Content.ReadAsAsync<string>();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }

            return "";
        }

    }
}