using Newtonsoft.Json;
using System.Text;
using Library.Application.Dtos.Publisher;
using library.application.Core;
using library.application.Models.Publisher;
using Library.Application.Contracts;

namespace Library.Web.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = "http://localhost:5038/api/Publisher";
        }

        public async Task<ServiceResult<IEnumerable<PublisherGetModel>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<PublisherGetModel>>();

            using (var response = await _httpClient.GetAsync(_baseUrl + "GetPublishers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ServiceResult<IEnumerable<PublisherGetModel>>>(apiResponse);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error obteniendo los editores.";
                }
            }

            return result;
        }

        public async Task<ServiceResult<PublisherGetModel>> Get(int id)
        {
            var result = new ServiceResult<PublisherGetModel>();

            using (var response = await _httpClient.GetAsync(_baseUrl + $"GetPublisherById?id={id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ServiceResult<PublisherGetModel>>(apiResponse);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error obteniendo editor.";
                }
            }

            return result;
        }

        public async Task<ServiceResult<bool>> Save(PublisherAddDto publisher)
        {
            var result = new ServiceResult<bool>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(publisher), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(_baseUrl + "SavePublisher", content))
            {
                result.Data = response.IsSuccessStatusCode;
                if (!response.IsSuccessStatusCode)
                {
                    result.Success = false;
                    result.Message = "Error guardando editor.";
                }
            }

            return result;
        }

        public async Task<ServiceResult<bool>> Update(PublisherUpdateDto publisher)
        {
            var result = new ServiceResult<bool>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(publisher), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(_baseUrl + "UpdatePublisher", content))
            {
                result.Data = response.IsSuccessStatusCode;
                if (!response.IsSuccessStatusCode)
                {
                    result.Success = false;
                    result.Message = "Error actualizando editor.";
                }
            }

            return result;
        }

        public async Task<ServiceResult<bool>> Remove(PublisherRemoveDto publisher)
        {
            var result = new ServiceResult<bool>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(publisher), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(_baseUrl + "DeletePublisher", content))
            {
                result.Data = response.IsSuccessStatusCode;
                if (!response.IsSuccessStatusCode)
                {
                    result.Success = false;
                    result.Message = "Error eliminando editor.";
                }
            }

            return result;
        }

        
    }
}
