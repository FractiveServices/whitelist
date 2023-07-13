-- Example implementation for the Fractive whitelisting API

local api = require(game:GetService("ServerStorage"):WaitForChild("Fractive").Whitelist.WhitelistApi);

game:GetService("Players").PlayerAdded:Connect(function(plr)
	local auth = api.isUserAuthorized(api, plr.UserId);
	
	if auth == false then
		plr:Kick("Not on whitelist.");
		warn("FRCV: "..plr.UserId.." denied access");
	else
		warn("FRCV: "..plr.UserId.." is allowed");
	end
end)
