﻿namespace UniSabana.ApiLibreriaKml.Response
{
    /// <summary>
	/// ApiResponseBase
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ApiResponseBase<T>
    {
        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// IsSuccessful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Messages
        /// </summary>
        public IEnumerable<string>? Messages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public T? Result { get; set; }
    }
}
