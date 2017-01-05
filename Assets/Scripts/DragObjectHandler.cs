using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface DragObjectHandler : IEventSystemHandler {
	void HandlePointerClickDown();
	void HandlePointerClickUp();
}
