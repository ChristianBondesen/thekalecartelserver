﻿namespace TheKaleCartelWebApi.Controllers.Parameters
{
    public class KaleProfileParameters
    {
        private const int MaxSize = 20;


        private int _pageSize = 10;
        public int PageSize { get => _pageSize; set => _pageSize = value < MaxSize ? value : MaxSize; }

        private int _pageNumber = 1;
        public int PageNumber { get => _pageNumber; set => _pageNumber = value > 1 ? value : 1; }

    }
}
