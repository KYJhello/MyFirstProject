using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon
{
    //========================================
    //##		������ ���� SingleTon		##
    //========================================
    /*
        �̱��� ���� :
        ���� �� ���� Ŭ���� �ν��Ͻ����� ������ ����
        �̿� ���� �������� �������� ����

        ���� :
        1. �������� ���� ������ �ν��Ͻ��� �ּҸ� ���� ����
        ������ ���� �޸� ������ Ȱ�� (��������)
        2. ���������� Ȱ���Ͽ� ĸ��ȭ�� ����
        3. �������� ���ٱ����� �ܺο��� ������ �� ������ ����
        4. Instance �Ӽ��� ���� �ν��Ͻ��� ������ �� �ֵ��� ��
        5. instance ������ �� �ϳ��� �ֵ��� ����

        ���� :
        1. �ϳ����� ����� �ֿ� Ŭ����, �������� ������ ��
        2. ������ �������� ������ �ʿ��� �۾��� ���� �������ٰ���
        3. �ν��Ͻ����� �̱����� ���Ͽ� �����͸� �����ϱ� ������

        ���� :
        1. �̱����� �ʹ� ���� å���� �������� ��츦 �����ؾ���
        2. �̱����� ���߷� ���������� �������� �Ǵ� ���, ������ �ڵ� ���յ��� ������
        3. �̱����� �����͸� ������ ��� ������ ������ �����ؾ���
    */
    private static SingleTon instance;

    public static SingleTon Instance
    {
        get
        {
            if (instance == null)
                instance = new SingleTon();

            return instance;
        }
    }

    private SingleTon() { }

}

public class Inventory
{
    private static Inventory instance;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
                instance = new Inventory();
           
            return instance;
        }
    }
    private Inventory()
    {

    }
    public void PushItem()
    {

    }
    public void PopItem() { 
    
    }
}
public class Player
{
    Inventory inventory1;
    Inventory inventory2;

    public Player()
    {

    }

    public void GetItem()
    {
        
    }
    public void useItem()
    {

    }
}