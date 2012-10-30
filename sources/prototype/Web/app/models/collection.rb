class Collection < ActiveRecord::Base
  attr_accessible :nom, :year

  has_many :video

end
