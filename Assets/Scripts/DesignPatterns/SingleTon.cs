using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade : MonoBehaviour
{
    //========================================
    //##		������ ���� SingleTon		##
    //========================================
    /*
        �̱��� ���� : ex) �κ��丮 / ����Ʈ�Ŵ��� �� ���� ������ ����

        ���� �� ���� Ŭ���� �ν��Ͻ����� ������ ����
        �̿� ���� �������� �������� ����

        ���� :
        1. �������� ���� ������ �ν��Ͻ��� �ּҸ� ���� ����
        ������ ���� �޸� ������ Ȱ�� (��������)
        2. ���������� Ȱ���Ͽ� ĸ��ȭ�� ����
        3. �������� ���ٱ����� �ܺο��� ������ �� ������ ���� -> private�� �����
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

    public class Inventory
    {
        private static Inventory instance;
        private Inventory()                   // �����ڸ� �����̺����� ����
        {

        }

        public static Inventory GetInstance()        // �ܺο��� new�� ������ �Ұ����ϹǷ� Ŭ���� ���ο��� ����.
        {
            if (instance != null)
                return instance;

            instance = new Inventory();
            return instance;
        }
    }

    public class SingleTon
    {
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

    public class Player                               //�̱����� ���
    {
        public void Test()
        {
            SingleTon singleton1 = SingleTon.Instance;
            SingleTon singleton2 = SingleTon.Instance;
            SingleTon singleton3 = SingleTon.Instance;
            SingleTon singleton4 = SingleTon.Instance;

            // SingleTon sigleTon = new SingleTon();  ���������� ������ �ܺο��� ���������.
        }
    }
}
