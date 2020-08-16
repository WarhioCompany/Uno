﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    public bool isSpecial;

    public enum colors{Red, Yellow, Green, Blue, Black}
    public enum specials { plus2 = 10, res, skip, plus4, colorMatch}

    public int special;

    public int color;
    public int value;

    public GameObject gO;
}