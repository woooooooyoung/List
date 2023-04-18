using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    // 1. 선형리스트 구현 - msdn C# List 참고
    //    인덱서[], Add, Remove, Find, FindIndex, Count, 등
    // 2. 배열, 선형리스트 기술면접 정리
	internal class List<T>
	{
		private const int DefaultCapacity = 4;

		private T[] items;
		private int size;

		public List()
		{
			items = new T[DefaultCapacity];
			size = 0;
		}

		public int Capacity { get { return items.Length; } }
		public int Count { get { return size; } }

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= size)
					throw new IndexOutOfRangeException();

				return items[index];
			}
			set
			{
				if (index < 0 || index >= size)
					throw new IndexOutOfRangeException();

				items[index] = value;
			}
		}

		public void Add(T item)
		{
			if (size < items.Length)
			{
				items[size++] = item;
			}
			else
			{
				Grow();
			}

		}

		public void Clear()
		{
			items = new T[DefaultCapacity];
			size = 0;
		}

		public T? Find(Predicate<T> match)
		{
			if (match == null) throw new ArgumentNullException();

			for (int i = 0; i < size; i++)
			{
				if (match(items[i]))
					return items[i];
			}

			return default(T);
		}

		public int FindIndex(Predicate<T> match)
		{
			return FindIndex(0, size, match);
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			if (startIndex > size)
				throw new ArgumentOutOfRangeException();
			if (count < 0 || startIndex > size - count)
				throw new ArgumentOutOfRangeException();
			if (match == null)
				throw new ArgumentNullException();

			int endIndex = startIndex + count;
			for (int i = startIndex; i < endIndex; i++)
			{
				if (match(items[i])) return i;
			}
			return -1;
		}

		public int IndexOf(T item)
		{
			return Array.IndexOf(items, item, 0, size);
		}

		public bool Remove(T item)
		{
			int index = IndexOf(item);						// 아이템을 검색
			if (index >= 0)									// 인덱스가 0보다 크거나 같으면 실행
			{
				RemoveAt(index);							// 인덱스를 제거
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= size)					// index가 0보다 크거나 index가 size랑 같거나 클때 실행
				throw new IndexOutOfRangeException();       // 예외 처리

            size--;											
			Array.Copy(items, index + 1, items, index, size - index);
		}

		private void Grow()
		{
			int newCapacity = items.Length * 2;				// 새로운 크기를 결정하고 크기를 2배로 늘림
			T[] newItems = new T[newCapacity];				// item의 새로운 배열을 선언
			Array.Copy(items, 0, newItems, 0, size);		// 원래 있었던 데이터(배열 들을 새로운 곳으로 복사
			items = newItems;								// 이전 아이템을 담고 있던 배열을 새로 선언한 배열로 이동
		}
	}
}