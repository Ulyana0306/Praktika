﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kursachik
{
    public abstract class Stock//Склад
    {
        public  List<Product> details = new List<Product>() //список продукции
        {
            new Product("Щебень из плотных горных пород","фракции 5-10 мм III группы",20.73,346),
            new Product("Щебень из плотных горных пород","фракции 5-20 мм I группы",24.31,198),
            new Product("Щебень из плотных горных пород","фракции 5-20 мм II группы",22.72,313),
            new Product("Щебень из плотных горных пород","фракции 5-20 мм III группы",20.13,225),
            new Product("Щебень из плотных горных пород","фракции 5-20 мм IVгруппы",19.97,486),
            new Product("Щебень из плотных горных пород","фракции 10-20 мм I группы",19.86,260),
            new Product("Щебень из плотных горных пород","фракции 10-20 мм III группы",18.73,539),
            new Product("Щебень из плотных горных пород","фракция 10-15 мм I группы",24.31,174),
            new Product("Щебень из плотных горных пород","фракция 20-40 мм II группы",15.94,633),
            new Product("Щебень из плотных горных пород","фракции 20-40 мм III группы",14.35,388),
            new Product("Щебень из плотных горных пород","фракции 40-70 мм IV группы",16.74,511),
            new Product("Щебень из плотных горных пород","фракции 40-70 мм II группы",18.68,277),
            new Product("Щебень из плотных горных пород","фракция 70-120 мм II группы",14.95,198),
            new Product("Щебень кубовидный из плотных горных пород","фракции 5-10 мм II сорта",20.56,556),
            new Product("Щебень для балластного слоя","фракции 31,5/63 мм",18.93,743),
            new Product("Щебень для балластного слоя","фракции 31,5/50 мм FL15",17.67,421),
            new Product("Щебень для балластного слоя","фракция 31,5/50 мм FL35",19.72,587),
            new Product("Щебень из горных пород","фракции 8-16 мм Л10",19.73,710),
            new Product("Щебень из горных пород","фракция 8-16 мм Л25",18.63,453),
            new Product("Щебень из горных пород","фракция 4-16 мм Л25",20.13,518),
            new Product("Щебень из горных пород","фракции 4-16 мм Л15",22.72,703),
            new Product("Щебень из горных пород","фракции 16-31,5 мм Л20",14.76,375),
            new Product("Щебень из горных пород","фракции 31,5-63 мм Л30",13.95,744),
            new Product("Щебень из горных пород","фракция 16-22,4 Л10",14.88,420),
            new Product("Крупный заполнитель для бетона","фракции 4/8 мм FL15",25.30,501),
            new Product("Крупный заполнитель для бетона","фракции 4/8 мм FL35",19.35,628),
            new Product("Крупный заполнитель для бетона","фракции 4/16 мм FL15",22.69,641),
            new Product("Крупный заполнитель для бетона","фракции 4/16 мм FL15 ДСЦ-2",24.12,812),
            new Product("Крупный заполнитель для бетона","фракции 4/16 мм FL35",18.79,160),
            new Product("Крупный заполнитель для бетона","фракции 8/16 мм FL15",22.69,280),
            new Product("Крупный заполнитель для бетона","фракции 8/16 мм FL35",18.42,439),
            new Product("Крупный заполнитель для бетона","фракции 16/32 мм FL15",15.94,562),
            new Product("Крупный заполнитель для бетона","фракции 16/22 мм FL35",14.88,741),
            new Product("Щебеночно-песчаная смесь для дорожного строительства","марки С5",14.95,945),
            new Product("Щебеночно-песчаная смесь для дорожного строительства","марки С6",13.95,814),
            new Product("Смесь заполнителей","фракции 0/32 мм",15.57,438),
            new Product("Смесь заполнителей","фракции 0/4 мм",14.83,506),
            new Product("Неликвиды","Нож 4075.00.001 95кг (обр.)",402.20,9),
            new Product("Неликвиды","Нож левый Д610-0101-05 22кг.(обр.)",148.57,22),
            new Product("Неликвиды","Нож правый Д610-0101-04 22кг.(обр.)",148.57,22),
            new Product("Неликвиды","Плита дробящая СМД60-117.3430.01.033 №14 1060кг (обр)",4240.84,5),
            new Product("Неликвиды","Плита дробящая СМД60-117.3430.01.031 №16 670кг (обр)",2968.23,2),
            new Product("Неликвиды","Футеровка 3023.00.005 398кг.(обр.)",735.04,7),
            new Product("Неликвиды","Футеровка 3023.00.002-01 270кг (обр.)",987.13,3),
            new Product("Неликвиды","Футеровка 3023.00.001 181кг (обр)",882.05,4),
            new Product("Неликвиды","Клин 1601.00.001-01 29,8кг",430.66,6),
            new Product("Неликвиды","Нож Д 610-01.01 31кг",128.95,2),
            new Product("Неликвиды","Нож Д 610-01.01-01 31кг",107.46,12),
            new Product("Неликвиды","Нож Д610-0101 31кг",109.75,7),
            new Product("Неликвиды","Сухарь 2922.00.002-10 515кг",1330,6),
            new Product("Неликвиды","Футеровка боковая 3462.01.006-01 370кг",1100,8),
            new Product("Отсев фракционированный","фракции 2,5-5 мм",8.77,149)
            
        };
    }
}
