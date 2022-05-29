using System;

[Serializable]
public class SaveData
{
    public int Version = 1010000;
    public float[] Positions;       // x, y
    public int[] IdStatusItemCount; //{ 2, 3, 4, 5, 6, 7, 8, 9, 10 }  //id ��������, ���������, ���-�� ���������.
    public short[][] Items;         // id, number of items, Durability, state, level, enchants
    public byte[] EquippedSlot;
}
