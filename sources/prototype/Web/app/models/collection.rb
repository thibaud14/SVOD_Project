class Collection < ActiveRecord::Base
  attr_accessible :name, :year

  has_many :videos

end
