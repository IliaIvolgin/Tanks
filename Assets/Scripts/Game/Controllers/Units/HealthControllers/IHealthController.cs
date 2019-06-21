﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers.Units.HealthControllers
{
	public interface IHealthController
	{
		void AddDeadEvent(ref Action actionEvent);
		float GetCurrentDamage(float inputDamage);
	}
}